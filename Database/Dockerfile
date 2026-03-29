# Use official SQL Server 2022 image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrongP@ssw0rd

# Create directory for initialization scripts
RUN mkdir -p /var/opt/mssql/scripts

# Copy seed SQL script into container
COPY ./CreateDatabaseAndSeed.sql /CreateDatabaseAndSeed.sql

# Run SQL Server and seed database
CMD /opt/mssql/bin/sqlservr & \
    sleep 90 && \
    /opt/mssql-tools18/bin/sqlcmd -C -S database -U sa -P YourStrongP@ssw0rd -d master -i /CreateDatabaseAndSeed.sql && \
    wait
