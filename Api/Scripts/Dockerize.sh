#!/bin/bash
set -e
cd ..

if [[ $(docker ps -q -f "name=api-container") ]]; then
    docker stop api-container
fi

if [[ $(docker ps -a -q -f "name=api-container") ]]; then
    docker rm api-container
fi

if [[ $(docker images -q api-image) ]]; then
    docker image rm api-image
fi

docker build -t api-image -f Dockerfile .
docker create --name api-container api-image
docker start api-container