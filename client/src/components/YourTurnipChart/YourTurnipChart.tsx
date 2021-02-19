import React, { useEffect } from 'react';
import { useTheme } from '@material-ui/core/styles';
import { LineChart, Line, XAxis, YAxis, Label, ResponsiveContainer, Tooltip } from 'recharts';
import Title from '../Title/Title';
import StalkApi from '../../api/StalkApi';
import IStalk from '../../interfaces/IStalk';

interface IData {
  time: string;
  amount: number;
}

const makeDataFromStalks = (stalks: IStalk[]): IData[] => (
  stalks.map(s => ({ time: s.date.toString(), amount: s.shopPrice }))
)

export default function YourTurnipChart() {
  const theme = useTheme();

  const stalkApi = new StalkApi();

  const [stalks, setStalks] = React.useState<IStalk[]>([]);

  useEffect(() => {
    (async function retrieveStalks() {
      const stk = await stalkApi.getStalks();
      setStalks(stk);
      console.log(stk);
    })();
  }, []);

  const data = makeDataFromStalks(stalks);

  return (
    <React.Fragment>
      <Title>Today</Title>
      <ResponsiveContainer>
        <LineChart
          data={data}
          margin={{
            top: 16,
            right: 16,
            bottom: 0,
            left: 24,
          }}
        >
          <XAxis dataKey="time" stroke={theme.palette.text.secondary} />
          <YAxis stroke={theme.palette.text.secondary}>
            <Label
              angle={270}
              position="left"
              style={{ textAnchor: 'middle', fill: theme.palette.text.primary }}
            >
              Shop Price ($B)
            </Label>
          </YAxis>
          <Tooltip />
          <Line type="monotone" dataKey="amount" stroke={theme.palette.primary.main} dot={false} />
        </LineChart>
      </ResponsiveContainer>
    </React.Fragment>
  );
}