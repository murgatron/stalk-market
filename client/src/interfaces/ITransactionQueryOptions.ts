import { TransactionType } from "./TransactionType";

export default interface ITransactionQueryOptions {
  type: TransactionType;
  sortBy: string; // format property:asc or property:desc
}