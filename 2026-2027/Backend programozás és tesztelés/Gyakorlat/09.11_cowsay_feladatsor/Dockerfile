FROM ubuntu:latest

RUN apt-get update && apt-get install -y cowsay

ENTRYPOINT ["/usr/games/cowsay"]

CMD ["Milyen csodás ez a nap!"]

# docker build -t monogram/cowsay:ubuntu .
# docker run --rm --name cowsay monogram/cowsay:ubuntu