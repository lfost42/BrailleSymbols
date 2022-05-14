# BrailleSymbols

The special list of symbols are defined by committee and published in html format - https://iceb.org/symbsc2.html. This web app consumes an API that makes the information accessible, searchable, and maintainable. It also allows the community to be involved in keeping the information updated and accurate. 

This will be part of a tool that will help transcribers format the Special Symbols Page in Braille transcriptions. It's also a piece of a braille training ecosystem I am designing. 

![My App](./app.png)

## WALKTHROUGH
An administrative dashboard for maintaining a database of braille special symbols. Designed, tested, and deployed following Open API Specification standards using Swagger. 

## OPEN REQUIREMENTS

MVP 
- A dashboard that allows authenticated users can search, create, update, and delete records from the Special Symbols database through the BrailleSymbolsAPI. 
- FosterPi API provides authentication using Linkedin OAuth 2.0. 

PLANNED UPDATES
- Create a service that scrapes symbols from the ICEB database
- Create a service that adds unique symbols to the database
- Create a service that sorts symbols into ascii-braille order

## USER INTERFACE
A dashboard that enables CRUD operations on records in the Braille Special Symbols database. 

## LOGIC DESIGN
BrailleSymbolsAPI provides access to the database.
FosterPi API provides authentication to limit who can access and modify the database.

## DATA DESIGN
AsciiModel - ascii characters that make up a symbols, one-to-many relationship with SpecialSymbols
SpecialSymbolsModel - name of symbol and matching ascii


