http://callistaenterprise.se/blogg/teknik/2017/12/18/docker-in-swarm-mode-on-docker-in-docker/
docker service create --name event-collector-server  --detach=false -p 8080:80 pryabov/event-collector-server:latest


- docker build -t event-collector-server -f EventCollectorServer.Api/Dockerfile .
- docker login
- docker run -d -p 8080:80 event-collector-server:latest
- docker images
- docker container ls
- docker container stop 363f417e254f
- docker container rm 363f417e254f
- docker tag 64aa85cb7994 pryabov/event-collector-server:latest
- docker push pryabov/event-collector-server
