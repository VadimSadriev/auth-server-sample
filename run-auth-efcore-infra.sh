#!/bin/bash
echo "-- building migrator.."
docker-compose -f docker-compose-efcore.yaml build migrator
echo "-- completed building migrator.."
sh ./docker-clean-efcore.sh

echo "-- running database with migrations.."
docker-compose -f docker-compose-efcore.yaml up -d database
docker-compose -f docker-compose-efcore.yaml run migrator
docker ps