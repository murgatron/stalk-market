# stalk-market server 

the architecture of the server

# swagger

/api/v1/villagers

GET PUT POST DELETE

{
    id: string;
    name: 
    // TODO more info! 
}

/api/v1/islands

GET PUT POST DELETE

{ 
    id: string;
    name: string;
    owner: fk villagerid;
}

/api/v1/stalks

GET PUT POST DELETE

{
    id: string;
    islandId: fk islandId 
    meridian: 'am' or 'pm';
    bells: number;
    date: timestamptz
    enteredBy: fk villagerid;
}

# erd