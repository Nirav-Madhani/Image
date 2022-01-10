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

9. Now we need to connect to server via SSH.  Click SSH button in Console.
10. We also need to Transfer Files from WinSCP to GCP computer. In win SCP configure as follows
![image](https://user-images.githubusercontent.com/77914957/148774424-65e2e792-710e-4095-b345-8f1cf49fa9e5.png)

Click Advance and ..

![image](https://user-images.githubusercontent.com/77914957/148774548-1134779d-d6b5-40f6-b798-094c4727ead6.png)

11. Now go to `Python` Folder in the Project and transfer that to server

![image](https://user-images.githubusercontent.com/77914957/148774843-0a956b63-65d0-4ff7-a452-6d1ac515447b.png)

Here you can see I have all permissions granted already for main.py and ServerBuild.x86_64
You can do the same via SSH console using

`sudo chmod +777 <filename(s)>`

