import { TransactionType } from "./TransactionType";

export interface ITransaction {
  id: string;
  price: number;
  type: TransactionType;
  onIsland: string;
  villagerId: string;
  quantity: number;
  timestamp: Date;
}