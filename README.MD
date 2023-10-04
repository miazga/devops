# DevOps for simple startup project
- Deploy .NET App in a few steps using your Domain, VPS and GitHub actions
- Create and maintain the SSL Cerficate automagically

## Prerequisites:
- Ubuntu 20.4 VPS
- Custom Domain
- Cloudflare account
- Github Repo
- Docker Hub account

## How to

### VPS
- Buy a VPS running Ubuntu with a Docker (!important)
- Login to the VPS using SSH
- Install docker-compose using: `sudo curl -L "https://github.com/docker/compose/releases/download/v2.14.0/docker-compose-linux-x86_64" -o /usr/local/bin/docker-compose`
- Allow the compose to execute using `sudo chmod +x /usr/local/bin/docker-compose`
- Open port 443 for HTTPS connection using: `sudo ufw allow 443/tcp`

### Domain
- Buy a domain
- Create Cloudflare Account + add the Domain to your panel:
![Cloudflare Nameservers to be added in your provider](/docs/cloduflare-dns.jpg)

- Open Domain Provider config page for a domain and change these to the ones provided by Cloudflare:
![OVH Configuration of the DNS Nameservers](/docs/setup-dns-ovh.jpg)

### Docker Hub
- Create a new account or use existing
- Navigate to the security section of the settings: https://hub.docker.com/settings/security and gather access token
![DockerHub Settings and Security](/docs/docker-hub-accesstoken.jpg)


### Github
- Create a new repo or use existing, then navigate to secrets in `Setting -> Secrets and variables -> Actions`
![Github Secrets for the repository](/docs/github-secrets.jpg)

- `VPS_HOST` - IP Address of your VPS
- `VPS_PORT` - SSH port used for remote shell execution (22 by default)
- `VPS_USERNAME` - User to execute shell commands (root by default)
- `VPS_PASSWORD` - Password for the given user

- `DOCKERHUB_USERNAME` - Your Docker user name
- `DOCKERHUB_TOKEN` - Access token for a given user

- `DOMAIN` - The domain you want to use (eg. www.anything.com)


## Files needed

| File | Content | Where to put? |
| - | - | - |
| `.github/` | folder with the workflow for CD | root of your project |
| `run.sh` | script to run docker-compose on VPS | root of your project |
| `docker-compose.yml` | definitions of the services to run, adjust images accordingly | root of your project |
| `docker-compose.proxy.yml` | definitions of the reverse-proxy and letsencrypt SSL provider | root of your project |
| `src/WebUI/Dockerfile` | Dockerfile for your Web project | where .csproj for the project lives |
| `src/Worker/Dockerfile` | Dockerfile for your Worker project | where .csproj for the project lives |



## How to modify files
- Copy all the files from above
- Run `git update-index --add --chmod=+x run.sh` in root directory - this will make the bash script executable everywhere
- Adjust `Dockerfile` for the Projects you want to deploy - you can use the Dockerfile from here
- Adjust the paths to the `Dockerfile` in `.github/workflows/continuous-deployment.yml`
![Dockerfile path adjustment](/docs/adjust-dockerfile-path.jpg)
- Adjust the Docker Hub Image for projects
![Docker Hub image adjustment](/docs/adjust-dockerhub-image-name.jpg)
- Commit all the changes and wait for the Action Pipeline to Run:
![Queued Deployment Action](/docs/queued-deployment-action.jpg)
