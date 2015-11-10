FROM ubuntu
COPY . /usr/local/app/
RUN sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF && \
        echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list && \
        apt-get update && apt-get upgrade -y && apt-get install -y mono-xsp4 screen sqlite3 && chmod 777 /var/run/screen
RUN cd /usr/local/app/ && xbuild
CMD cd /usr/local/app/WebGoat && xsp4
