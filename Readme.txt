TODO/ Plan so far: (25th Aug, 2023)

1. Use polygon.io api to get tickers data
   - Create Ticker Model: DONE
   - Write backend to call API and get data: DONE

2. Save Data to database
   - Use Linq, lambdas
   - Use entity framework, migrations: DONE (isse encountered, needed to add : TrustServerCertificate=true; in connection string)
   - Setup local DB: DONE
   - Create Data access Layer

3. Web API to get data
   - Create Web API to get data from DB for particular ticker or set of tickers
   - Improve processing (async/await etc)

4. Display basic Ticker data on one page:
  - Simple Razor Page: DONE
  - Add Pagination or some filters to select Tickers
 
5. Improvements:
  - Convert this to Library
  - Add an angular frontend for faster processing
  - OR an angular webapp with this backend
