import React, { Fragment, useEffect } from 'react';
import Link from '@material-ui/core/Link';
import NotificationsIcon from '@material-ui/icons/Notifications';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Title from '../Title/Title';
import TransactionApi from '../../api/TransactionApi';
import ITransaction from '../../interfaces/ITransaction';
import { TransactionType } from '../../interfaces/TransactionType';

function preventDefault(event: any) {
  event.preventDefault();
}

const useStyles = makeStyles({
  depositContext: {
    flex: 1,
  },
});

export default function TopSellers() {
  const classes = useStyles();

  const trxApi = new TransactionApi();

  const [topSale, setTopSale] = React.useState<ITransaction>();

  const [sells, setSells] = React.useState<ITransaction[]>([]);

  useEffect(() => {
    (async function retrieveTransactions() {
      const trx = await trxApi.getTransactions({ type: TransactionType.Sell, sortBy: 'price:desc' });
      setSells(trx);

      console.log(trx);

      setTopSale(trx[0])
    })();
  }, []);

  return (
    <React.Fragment>
      <Title>Top Sellers</Title>
      { topSale &&
        (<Fragment>
          <Typography component="p" variant="h4">
            <NotificationsIcon /> {topSale.price}
          </Typography>
          <Typography color="textSecondary" className={classes.depositContext}>
            by {topSale.villagerId} on {topSale.timestamp}
          </Typography>
        </Fragment>)
      }
      <div>
        <Link color="primary" href="#" onClick={preventDefault}>
          View other sellers
        </Link>
      </div>
    </React.Fragment>
  );
}