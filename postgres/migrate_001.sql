$$
DO

-- TODO: check if migration has already been run 

create table "migration" (
    version int NOT NULL,
    description text NOT NULL
);

create table "villager" (
    id UUID primary key,
    name text NOT NULL
);

create table "island" (
    id UUID primary key,
    name text NOT NULL,
    owner_id UUID NOT NULL
);

create table "stalk" (
    id UUID primary key,
    meridian varchar(3) NOT NULL,
    date timestamptz NOT NULL,
    bell_price int NOT NULL,
    island_id UUID NOT NULL,
    entered_by UUID NOT NULL
);

alter table "island" add constraint owner_id_fk foreign key (owner_id) references "villager" ('id');

alter table "stalk" add constraint island_id_fk foreign key (island_id) references "island" ('id');
alter table "stalk" add constraint entered_by_fk foreign key (entered_by) references "villager" ('id');

insert into table "migration" (version, description) values(1, "Initial migration");

END
$$