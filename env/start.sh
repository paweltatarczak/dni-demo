#!/bin/bash

#chown -R 1000:1000 /volumes/jenkins

cd compose
docker-compose up -d --build
