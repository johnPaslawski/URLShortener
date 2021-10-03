# URLShortener
------------
Business context document: URL Shortener.pdf 
------------
URLShortener - simple MVP example product with EntityFramework ORM &amp; MSSql database, which exhibits proposed fuctionality of URL shortening widget in any core commercial product. Works in terms of exchanging links within a company

URLShoreten consists of 2 main parts - Frontend & Backend. 
Frontent (urlshortener_frontend folder) is designed as "ready to use" React App, designed to be embedded in any other core product as a widget. It needs running backend in order to work.
Backend is separate REST-API with SQL Server database (mouned locally - in order to work one shoud change connection string and create own database). Backend uses EntityFramework as ORM and GenericRepository as DAO.

Until this project is hosted online the domain name is set to be "http://localhost:[number]/" and shortening links works accordingly, which means shortened link starts with "http://localhost:[number]/", and 5 characters guid is added as unique identifier.
