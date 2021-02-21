docker-compose -f docker-compose-efcore.yaml build
docker rmi -f $(docker images -q --filter label=stage=build)
docker-compose -f docker-compose-efcore.yaml up -d
docker ps
