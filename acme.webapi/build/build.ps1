docker build -f flyway.dockerfile --force-rm -t acme/flyway .
docker rmi $(docker images -f dangling=true -q --no-trunc)