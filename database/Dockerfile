FROM mcr.microsoft.com/mssql/server:2019-latest

# Create a config directory
RUN mkdir -p /usr/share/db
WORKDIR /usr/share/db

# Bundle config source
COPY setup.sql /usr/share/db

# Grant permissions for to our scripts to be executable
# RUN chmod +x /usr/config/entrypoint.sh
# RUN chmod +x /usr/config/configure-db.sh

ENTRYPOINT ["/opt/mssql/bin/sqlservr"]
