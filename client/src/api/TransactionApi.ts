import axios, { AxiosInstance } from "axios";
import { SERVER_HOSTNAME, SERVER_PORT } from "../constants";
import { ITransaction } from "../interfaces/ITransaction";

export default class TransactionApi {
  private transactionApi: AxiosInstance;

  constructor() {
    this.transactionApi = axios.create({
      baseURL: `${SERVER_HOSTNAME}:${SERVER_PORT}/api/v1/transactions`
    });
    console.log(this.transactionApi);
  }

  public async getTransactions(): Promise<ITransaction[]> {
    return this.transactionApi.get('')
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