#!/bin/bash
set -e
cd ..

# check to see if container is running
if [[ $(docker ps -q -f "name=api-container") ]]; then
    docker stop api-container
fi

# check to see if container needs to be removed
if [[ $(docker ps -a -q -f "name=api-container") ]]; then
    docker rm api-container
fi

# check to see if image needs to be removed
if [[ $(docker images -q api-image) ]]; then
    docker image rm api-image
fi

# build the new container
docker build -t api-image -f Dockerfile .
docker run -d --name api-container -p 9999:80 api-image