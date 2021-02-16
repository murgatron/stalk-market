import axios, { AxiosInstance } from "axios";
import { SERVER_HOSTNAME, SERVER_PORT } from "../constants";
import IVillager from "../interfaces/IVillager";

export default class VillagerApi {
  private villagerApi: AxiosInstance;

  constructor() {
    this.villagerApi = axios.create({
      baseURL: `${SERVER_HOSTNAME}:${SERVER_PORT}/api/v1/villagers`
    });
  }

  public async getStalks(): Promise<IVillager[]> {
    return this.villagerApi.get('')
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