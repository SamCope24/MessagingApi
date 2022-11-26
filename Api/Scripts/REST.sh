#!/bin/bash

# clear the logs
cd ..
> logs.txt

TOKEN=$( \
    curl -X POST https://localhost:9999/security/createToken \
    -H "Content-Type: application/json" \
    -d '{"userName":"sam","password":"changeme"}')

for MESSAGE in '"Message 1"' '"Message 2"' '"Message 3"'
do
    curl -X POST \
        https://localhost:9999/messaging/write \
        -H "Authorization: Bearer ${TOKEN}" \
        -H 'accept: text/plain' \
        -H 'Content-Type: application/json' \
        -d "$MESSAGE"
    echo
done

curl https://localhost:9999/messaging/read \
    -H "Authorization: Bearer ${TOKEN}" \
    -H 'Content-Type: application/json' \
