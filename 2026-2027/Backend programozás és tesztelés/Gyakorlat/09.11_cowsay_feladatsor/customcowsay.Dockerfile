FROM ubuntu:latest

RUN apt-get update && apt-get install -y cowsay

ENTRYPOINT ["/usr/games/cowsay"]

CMD ["Milyen csodás ez a nap!"]

# docker build -t monogram/customcowsay:ubuntu -f customcowsay.Dockerfile .
# docker run --rm --name customcowsay monogram/customcowsay:ubuntu