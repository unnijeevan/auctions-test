# Auctions coding test
The design is to implement each functionality as a micro-sercvice :-
1. User Service :- For Authentication and User Management.
2. Item Service :- To Add Items for sellers and for users of the systems to see ietms which are in auction . Could have search classification etc. 
3. Bidding Service :- This the only one partly implemented . Used to place bids on items in austion now and the logic around it . 
4. System Services :- A set of background services which will do some  functions like :-
   1.When Item has passed start date for auction publish start auction event . May be send email to seller or anyone watching the item.
   2. When Auction has finished end date ,a nd there is a active mark as sold. Publish event for other services to update. Notify buyer and seller by email . 
5. APIGateway : - Ocelot implmentation for API gateay for front end. Could add authorization with identity server . 

Initially I planned to mock all other services and add a front end but i have already passed the time frame for this assignment . Hence the working project is only BiddingService and BiddingService.Test. The background service to check for auction end is the same project . Unit tests have been added but no integration tests . .Net core 3.1 is required , to start project :-
1. Clone / download the github repository.
2. Open the solution in visual studio and set BiddingService as startup project. Run .
3. Goto  https://localhost:44315/ for swagger documentation. A bid can be placed using the api end point from swagger. Use item id from the seed data in /Init/SeedData . if testing of auction complete is also required , select one with faster end time. Exceute.
4. Watch the logs for Auction complete service. I am logging the itemId and selling price 

If you have docker for desktop installed , optionally you can checkout / download this branch https://github.com/unnijeevan/auctions-test/tree/DockerSupport.  Run docker-compose up from root. There is a single page app at http://localhost:5000/index.html which does basic things like showing list of items and placing a bid on it . Very primitive at the moment . Also since docker will run all services , swagger for bidding service can be accessed at localhost:9000 and the same placing bid, getting current bids can be done

# Note

I haven't done the cleanup to remove incomplete services because I would like to come back later and complete the other microservices later as a sample application.

