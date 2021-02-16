import { Box, Container, Grid, Paper, Typography } from "@material-ui/core";
import React, { Fragment } from "react";
import clsx from 'clsx';
import { appStyles } from "../styles";
import TurnipChart from "../components/TurnipChart/TurnipChart";
import AuthorCredits from "../components/AuthorCredits/AuthorCredits";

export default function BuysAndSells() {
  const classes = appStyles();

  const fixedHeightPaper = clsx(classes.paper, classes.fixedHeight);

  return (
    <Container maxWidth="lg" className={classes.container}>
      <Grid container spacing={3}>
        {/* Buy Graph */}
        <Grid item xs={12} md={5} lg={5}>
          <Paper className={fixedHeightPaper}>
            <Typography> Buy Graph </Typography>
            <TurnipChart />
          </Paper>
        </Grid>
        {/* Sell Graph */}
        <Grid item xs={12} md={5} lg={5}>
          <Paper className={fixedHeightPaper}>
            <Typography> Sell Graph </Typography>
            <TurnipChart />
          </Paper>
        </Grid>
        {/* Buy Table */}
        <Grid item xs={12} md={5} lg={5}>
          <Paper className={classes.paper}>
            <Typography> Buy Table </Typography>
          </Paper>
        </Grid>
        {/* Sell Table */}
        <Grid item xs={12} md={5} lg={5}>
          <Paper className={classes.paper}>
            <Typography> Sell Table </Typography>
          </Paper>
        </Grid>
      </Grid>
      <Box pt={4}>
        <AuthorCredits />
      </Box>
    </Container>
  );
}