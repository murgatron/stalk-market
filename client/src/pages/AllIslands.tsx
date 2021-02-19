import React from 'react';
import clsx from 'clsx';
import { Box, Container, Grid, Paper, Typography } from "@material-ui/core";
import { appStyles } from '../styles';
import AuthorCredits from '../components/AuthorCredits/AuthorCredits';
import AllTurnipChart from '../components/AllTurnipChart/AllTurnipChart';

export default function AllIslands() {
  const classes = appStyles();

  const fixedHeightPaper = clsx(classes.paper, classes.fixedHeight);

  return (
    <Container maxWidth="lg" className={classes.container}>
      <Grid container spacing={3}>
        {/* Stalks Chart */}
        <Grid item xs={12}>
          <Paper className={fixedHeightPaper}>
            <Typography> Island Stalks </Typography>
            <AllTurnipChart />
          </Paper>
        </Grid>
        {/* Island Activity */}
        <Grid item xs={12}>
          <Paper className={fixedHeightPaper}>
            <Typography> Island Stats </Typography>
          </Paper>
        </Grid>
        {/* More info about stalks */}
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography> Island Stalks Table </Typography>
          </Paper>
        </Grid>
      </Grid>
      <Box pt={4}>
        <AuthorCredits />
      </Box>
    </Container>
  );
}