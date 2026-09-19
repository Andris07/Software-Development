FROM ubuntu:latest

RUN apt-get update && apt-get install -y cowsay

COPY sources/meme.cow /usr/share/cowsay/cows

ENTRYPOINT ["/usr/games/cowsay", "-f", "meme"]

CMD ["Shabbat Shalom"]

# docker build -t monogram/memesay:ubuntu -f memesay.Dockerfile .
# docker run --rm --name memesay monogram/memesay:ubuntu