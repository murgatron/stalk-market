import React from 'react';
import clsx from 'clsx';
import Box from '@material-ui/core/Box';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Chart from '../components/TurnipChart/Chart';
import Deposits from '../components/TopSellers/Deposits';
import AuthorCredits from '../components/AuthorCredits/AuthorCredits';
import Transactions from '../components/Transactions/Transactions';
import { appStyles } from '../styles';

export default function Dashboard() {
  const classes = appStyles();

  const fixedHeightPaper = clsx(classes.paper, classes.fixedHeight);

  return (
    <Container maxWidth="lg" className={classes.container}>
      <Grid container spacing={3}>
        {/* Chart */}
        <Grid item xs={12} md={8} lg={9}>
          <Paper className={fixedHeightPaper}>
            <Chart />
          </Paper>
        </Grid>
        {/* Recent Deposits */}
        <Grid item xs={12} md={4} lg={3}>
          <Paper className={fixedHeightPaper}>
            <Deposits />
          </Paper>
        </Grid>
        {/* Transactions */}
        <Grid item xs={12}>
          <Paper className={classes.paper}>
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