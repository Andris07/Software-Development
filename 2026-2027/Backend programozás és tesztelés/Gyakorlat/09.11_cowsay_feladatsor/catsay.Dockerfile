FROM ubuntu:latest

RUN apt-get update && apt-get install -y cowsay

COPY sources/cat.cow /usr/share/cowsay/cows

ENTRYPOINT ["/usr/games/cowsay", "-f", "cat"]

CMD ["Miauu"]

# docker build -t monogram/catsay:ubuntu -f catsay.Dockerfile .
# docker run --rm --name catsay monogram/catsay:ubuntu