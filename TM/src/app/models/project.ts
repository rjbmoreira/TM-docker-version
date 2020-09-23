import { Customer } from './customer';

export interface Project {
    id: number;
    name: string;
    description: string;
    customerId: number;
    customer: Customer;
}