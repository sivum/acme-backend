docker rmi acme-runner/flyway 
docker build -f migrate.dockerfile --force-rm -t acme-runner/flyway .
docker run --rm -it --network=host -e HOST=localhost -e DB=acme -e USER=sa -e PORT=1433 acme-runner/flyway /bin/bash -c migrate.sh