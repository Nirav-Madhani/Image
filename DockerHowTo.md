# How To Dockerize the Build

## Configuring Server Before Build

Make Sure `NetworkAddress` of `NetworkManager` is pointing to `0.0.0.0` because docker requires you to point to this address to expose and publish your application.
Also, you cannot use KcpTransport with docker as it(KcpTransport) uses UDP and docker has know issue with UDP since 2015. (I found out this the hard way :smiling_face_with_tear:)

Therfore you will also need to change server and client to use TelepathyTransport or SimpleWebTransport.

## Docker File

Create a docker file in your build folder and put something like this

```dockerfile
FROM python:3.10-slim
EXPOSE 10000-10100

# Keeps Python from generating .pyc files in the container
ENV PYTHONDONTWRITEBYTECODE=1

# Turns off buffering for easier container logging
ENV PYTHONUNBUFFERED=1

# both files are explicitly required!

WORKDIR /app

COPY . /app
RUN chmod +x LinuxServer.x86_64
```

You can build this using command shown below or using VS Code extension(recommended). If you are using cmd, make sure to run this in same folder as dockerfile

```bash
docker build --pull --rm -f "dockerfile" -t ImageName:slim "." 
```
here ImageName represents name of container image.

## Running the Container

First time:
```bash
docker run -p 10000-10100:10000-10100 --name="ContainerName" -d ImageName python main.py
```

Subsequently Starting:
```
docker start ContainerName
```

Stoping:
```
docker stop ContainerName
```

ToDo: Share github workflow to auto build container when Build folder is commited, Not the traditional way though. Generally we may want to build LinusServer standlone and create container when code is updated and not the other way around.
