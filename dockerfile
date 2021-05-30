FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /parser_dates
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "parser_dates/bin/Debug/net5.0/parser_dates.dll"]
