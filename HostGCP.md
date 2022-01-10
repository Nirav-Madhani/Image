# Hosting on GCP

1. Make sure you have WinSCP, Putty and PuttyGen Installed
2. Generate key in PuttyGen (Press Generate Button and move mouse randomly)
3. Make Sure you are using version 2 

![image](https://user-images.githubusercontent.com/77914957/148772909-1dba433d-9257-4119-a650-a3e988e52fbe.png)

![image](https://user-images.githubusercontent.com/77914957/148772946-88901224-d9c9-433c-bd9f-17b0b4a65ff7.png)

4. Set `Key comment` as username to use later for login.
5. Save Private Key and copy public key.

![image](https://user-images.githubusercontent.com/77914957/148773300-ab4594c6-a026-468c-9b35-2a060d6e6257.png)
6. Create New VM Instance

![image](https://user-images.githubusercontent.com/77914957/148773363-1c0d46d1-ee5b-4d54-9435-91376d25dc02.png)

7. Make sure to add public key in meta-data of instance.

![image](https://user-images.githubusercontent.com/77914957/148773639-0049383b-27a3-47fb-b3d9-16af87e5ed68.png)

8. Configure VPC network to allow all ports

![image](https://user-images.githubusercontent.com/77914957/148773754-1e4262bd-4b22-425d-9b34-a28f9917d7f2.png)

Go To `Firewall > Create New Rule`

Suggested Confiugration:

![image](https://user-images.githubusercontent.com/77914957/148774105-d2ce567d-6dd5-42a9-874e-080c6437bbcf.png)

9. Now we need to connect to server via SSH.  Click SSH button in Console. Alternatively it is recommended to connect via putty. 

![image](https://user-images.githubusercontent.com/77914957/148775810-3cd1efca-7163-40e6-a48a-7ee72df69389.png)
![image](https://user-images.githubusercontent.com/77914957/148775913-2dcb27bb-022c-4fa3-9c4d-76e6017b7249.png)


In the username field enter username that you choose in step 4.
![image](https://user-images.githubusercontent.com/77914957/148776011-31b525d9-f195-400e-8b2c-07c2cba2e27b.png)


11. We also need to Transfer Files from WinSCP to GCP computer. In win SCP configure as follows
![image](https://user-images.githubusercontent.com/77914957/148774424-65e2e792-710e-4095-b345-8f1cf49fa9e5.png)

Click Advance and ..

![image](https://user-images.githubusercontent.com/77914957/148774548-1134779d-d6b5-40f6-b798-094c4727ead6.png)

12. Now go to `Python` Folder in the Project and transfer that to server. _Remember where you are copying. You need to access that from SSH later.
_
![image](https://user-images.githubusercontent.com/77914957/148774843-0a956b63-65d0-4ff7-a452-6d1ac515447b.png)

Here you can see I have all permissions granted already for `main.py` and `LinuxServer.x86_64`
You can do the same via SSH console using

`sudo chmod +777 <filename(s)>`

13. Install the python3 if not already installed. Also install `screen`. It is helpful when you want to keep Process on after closing connection from putty.
14. type `screen`
 `python3 main.py`. If this screen appears then setup was successful.

![image](https://user-images.githubusercontent.com/77914957/148775498-2604a798-a3cf-4973-ae4a-7d0c892ca25e.png)

15. Now to detach screen press Ctrl+A followed by d. You can close all windows now.
16. To access the console later, again start session in putty and type `screen -r`
