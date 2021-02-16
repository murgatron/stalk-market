import { Link, makeStyles, Table, TableBody, TableCell, TableHead, TableRow } from "@material-ui/core";
import React, { useEffect } from "react";
import TransactionApi from "../../api/TransactionApi";
import { ITransaction } from "../../interfaces/ITransaction";
import Title from "../../pages/Title";

export default function Transactions() {
  const trxApi = new TransactionApi();

  const [transactions, setTransactions] = React.useState<ITransaction[]>([]);

  useEffect(() => {
    (async function retrieveTransactions() {
      const trx = await trxApi.getTransactions();
      setTransactions(trx);
      console.log(transactions);
    })();
  }, []);

  function preventDefault(event: any) {
    event.preventDefault();
  }

  const useStyles = makeStyles((theme) => ({
    seeMore: {
      marginTop: theme.spacing(3),
    },
  }));

  const classes = useStyles();
  return (
    <React.Fragment>
      <Title>Transactions</Title>
      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Type</TableCell>
            <TableCell>Timestamp</TableCell>
            <TableCell>Villager</TableCell>
            <TableCell>Price</TableCell>
            <TableCell>Quantity</TableCell>
            <TableCell align="right">On Island</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {transactions.map((trx: ITransaction) => (
            <TableRow key={trx.id}>
              <TableCell>{trx.type}</TableCell>
              <TableCell>{trx.timestamp}</TableCell>
              <TableCell>{trx.villagerId}</TableCell>
              <TableCell>{trx.price}</TableCell>
              <TableCell>{trx.quantity}</TableCell>
              <TableCell align="right">{trx.onIsland}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <div className={classes.seeMore}>
        <Link color="primary" href="#" onClick={preventDefault}>
          See all buys and sells
          </Link>
      </div>
    </React.Fragment>
  );
}