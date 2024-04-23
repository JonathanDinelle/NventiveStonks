import axios, { AxiosInstance, AxiosRequestConfig } from "axios";

export function getHttpClient(baseURL: string): AxiosInstance {
  const config: AxiosRequestConfig = {
    baseURL,
  };

  const axiosInstance = axios.create(config);
  
  return axiosInstance;
}
