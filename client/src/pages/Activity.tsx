import React from 'react';
import clsx from 'clsx';
import { appStyles } from "../styles";
import { Box, Container, Grid, Paper, Typography } from '@material-ui/core';
import TurnipChart from '../components/TurnipChart/TurnipChart';
import AuthorCredits from '../components/AuthorCredits/AuthorCredits';
import Transactions from '../components/Transactions/Transactions';

export default function Activity() {
  const classes = appStyles();

  const fixedHeightPaper = clsx(classes.paper, classes.fixedHeight);

  return (
    <Container maxWidth="lg" className={classes.container}>
      <Grid container spacing={3}>
        {/* Common Activities */}
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography> Common Activities </Typography>
            <TurnipChart />
          </Paper>
        </Grid>
        {/* Active Villagers */}
        <Grid item xs={12} md={4} lg={3}>
          <Paper className={fixedHeightPaper}>
            <Typography> Active Villagers </Typography>
            <TurnipChart />
          </Paper>
        </Grid>
        {/* All Activity */}
        <Grid item xs={12} md={8} lg={9}>
          <Paper className={classes.paper}>
            <Typography> All Activity </Typography>
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