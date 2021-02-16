import axios, { AxiosInstance } from "axios"
import { SERVER_HOSTNAME, SERVER_PORT } from "../constants";
import IIsland from "../interfaces/IIsland";

export default class IslandApi {
  private islandApi: AxiosInstance;

  constructor() {
    this.islandApi = axios.create({
      baseURL: `${SERVER_HOSTNAME}:${SERVER_PORT}/api/v1/islands`
    })
  }

  public async getIslands(): Promise<IIsland[]> {
    const response = await this.islandApi.get('');
    return response.data;
  }
}