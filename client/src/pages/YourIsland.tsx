import { Box, Container, Grid, Paper, Typography } from "@material-ui/core";
import React from "react";
import clsx from 'clsx';
import AuthorCredits from "../components/AuthorCredits/AuthorCredits";
import { appStyles } from "../styles";
import TurnipChart from "../components/TurnipChart/TurnipChart";
import Transactions from "../components/Transactions/Transactions";

export default function YourIsland() {
  const classes = appStyles();

  const fixedHeightPaper = clsx(classes.paper, classes.fixedHeight);

  return (
    <Container maxWidth="lg" className={classes.container}>
      <Grid container spacing={3}>
        {/* Stalks Chart */}
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography> Island Stalks </Typography>
            <TurnipChart />
          </Paper>
        </Grid>
        {/* About the villager */}
        <Grid item xs={12} md={4} lg={3}>
          <Paper className={fixedHeightPaper}>
            <Typography> Villager Info </Typography>
          </Paper>
        </Grid>
        {/* Island Activity */}
        <Grid item xs={12} md={8} lg={9}>
          <Paper className={fixedHeightPaper}>
            <Typography> Island Stats </Typography>
          </Paper>
        </Grid>
        {/* More info about stalks */}
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography> Island Stalks Table </Typography>
            <Transactions />
          </Paper>
        </Grid>
      </Grid>
      <Box pt={4}>
        <AuthorCredits />
      </Box>
    </Container>
  );
}