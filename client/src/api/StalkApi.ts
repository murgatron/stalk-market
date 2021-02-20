import axios, { AxiosInstance } from "axios";
import https from 'https';
import { SERVER_HOSTNAME, SERVER_PORT } from "../constants";
import IStalk from "../interfaces/IStalk";

export default class StalkApi {
  private stalkApi: AxiosInstance;

  constructor() {
    this.stalkApi = axios.create({
      baseURL: `${SERVER_HOSTNAME}:${SERVER_PORT}/api/v1/stalks`,
      httpsAgent: new https.Agent({ rejectUnauthorized: false })
    });
  }

  public async getStalks(): Promise<IStalk[]> {
    return this.stalkApi.get('')
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