import axios from 'axios';
import { BASE_URL } from './constants';
/**
 * API client for interacting with server
 */
export default class VillagerApi {


  public static getVillagers(): Promise<any> {
    return axios.get(`${BASE_URL}/api/v1/villagers`);
  }

  public static createVillager(payload: any): Promise<any> {
    return axios.post(`${BASE_URL}/api/v1/villagers`, payload);
  }
}