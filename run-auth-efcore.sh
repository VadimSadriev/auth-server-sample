docker-compose -f docker-compose-efcore.yaml build
sh ./docker-clean-efcore.sh
docker-compose -f docker-compose-efcore.yaml up auth-server-efcore -d
docker ps
