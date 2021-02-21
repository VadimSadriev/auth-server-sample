#!/bin/bash

echo "-- cleaning docker images.."
docker rmi -f $(docker images -q --filter label=stage=build)
echo "-- completed cleaning docker images.."