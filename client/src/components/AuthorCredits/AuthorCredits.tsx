import { Link, Typography } from "@material-ui/core";
import { GitHub } from "@material-ui/icons";
import React from "react";

export default function AuthorCredits() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {'Made by '}
      <Link color="inherit" href="https://github.com/murgatron">
        <GitHub fontSize="small" /> murgatron
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}
