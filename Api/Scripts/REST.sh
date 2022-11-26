#!/bin/bash

TOKEN=$( \
    curl -X POST https://localhost:9999/security/createToken \
    -H "Content-Type: application/json" \
    -d '{"userName":"sam","password":"changeme"}')

echo $TOKEN

curl -X POST \
    https://localhost:9999/messaging/write \
    -H "Authorization: Bearer ${TOKEN}" \
    -H 'accept: text/plain' \
    -H 'Content-Type: application/json' \
    -d '"Test Message"'