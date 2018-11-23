http://callistaenterprise.se/blogg/teknik/2017/12/18/docker-in-swarm-mode-on-docker-in-docker/
docker service create --name event-collector-server  --detach=false -p 8080:80 pryabov/event-collector-server:latest
