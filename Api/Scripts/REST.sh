#!/bin/bash

TOKEN=$( \
    curl -X POST https://localhost:9999/security/createToken \
    -H "Content-Type: application/json" \
    -d '{"userName":"sam","password":"changeme"}')

curl https://localhost:9999/messaging/getSecretMessage \
    -H 'Accept: application/json' -H "Authorization: Bearer ${TOKEN}" 