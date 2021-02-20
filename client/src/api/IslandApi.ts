import axios, { AxiosInstance } from "axios"
import https from 'https';
import { SERVER_HOSTNAME, SERVER_PORT } from "../constants";
import IIsland from "../interfaces/IIsland";

export default class IslandApi {
  private islandApi: AxiosInstance;

  constructor() {
    this.islandApi = axios.create({
      baseURL: `${SERVER_HOSTNAME}:${SERVER_PORT}/api/v1/islands`,
      httpsAgent: new https.Agent({ rejectUnauthorized: false })
    })
  }

  public async getIslands(): Promise<IIsland[]> {
    return this.islandApi.get('')
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