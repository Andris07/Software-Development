FROM ubuntu:latest

RUN apt-get update && apt-get install -y cowsay

COPY sources/fox.cow /usr/share/cowsay/cows

ENTRYPOINT ["/usr/games/cowsay", "-f", "fox"]

CMD ["Miauu"]

# docker build -t monogram/foxsay:ubuntu -f foxsay.Dockerfile .
# docker run --rm --name foxsay monogram/foxsay:ubuntu