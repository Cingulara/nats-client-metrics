FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
RUN mkdir /app
WORKDIR /app

# copy the project and restore as distinct layers in the image
COPY src/*.csproj ./
RUN dotnet restore

# copy the rest and build
COPY src/ ./
RUN dotnet build
RUN dotnet publish --runtime linux-musl-x64 -c Release -o out --self-contained true

# build runtime image with DoD CA Certificates
FROM cingulara/openrmf-base:1.14.00
RUN apk update && apk upgrade

RUN mkdir /app
WORKDIR /app
COPY --from=build-env /app/out .
# Fix for broken build on Docker in GH is to put RUN true between multiple COPY statements :(
RUN true

# Create a group and user
RUN addgroup --system --gid 1001 cingularagroup \
&& adduser --system -u 1001 --ingroup cingularagroup --shell /bin/sh cingularauser
RUN chown -R cingularauser:cingularagroup /app

USER 1001
ENTRYPOINT ["./nats-client-metrics"]

LABEL org.opencontainers.image.source=https://github.com/Cingulara/nats-client-metrics
LABEL maintainer="dale.bingham@cingulara.com"
