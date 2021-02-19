import axios, { AxiosInstance } from "axios";
import { SERVER_HOSTNAME, SERVER_PORT } from "../constants";
import ITransaction from "../interfaces/ITransaction";
import ITransactionQueryOptions from "../interfaces/ITransactionQueryOptions";

export default class TransactionApi {
  private transactionApi: AxiosInstance;

  constructor() {
    this.transactionApi = axios.create({
      baseURL: `${SERVER_HOSTNAME}:${SERVER_PORT}/api/v1/transactions`
    });
    console.log(this.transactionApi);
  }

  public async getTransactions(query?: ITransactionQueryOptions): Promise<ITransaction[]> {
    return this.transactionApi.get('', { params: query })
      .then(response => {
        console.log(response);
        return response.data;
      })
      .catch(e => {
        console.error(e)
        throw e;
      });
  }
}