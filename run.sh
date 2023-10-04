#!/bin/bash

export DOMAIN=$1

dockerComposeProxyPath=`readlink -f "./docker-compose.proxy.yml"`
dockerComposePath=`readlink -f "./docker-compose.yml"`

echo "### Script variables:"
echo "- dockerComposeProxyPath: ${dockerComposeProxyPath}"
echo "- dockerComposePath: ${dockerComposePath}"
echo -e "\n"

echo -e "\n"
echo "### Starting the proxy:"
echo -e "\n"
docker-compose -f $dockerComposeProxyPath up -d

echo -e "\n"
echo "### Starting the application:"
echo -e "\n"
docker-compose -f $dockerComposePath up -d

echo -e "\n"