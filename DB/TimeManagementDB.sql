--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4
-- Dumped by pg_dump version 12.4

-- Started on 2020-09-22 20:17:30

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 204 (class 1259 OID 16402)
-- Name: Customers; Type: TABLE; Schema: public; Owner: vestas
--

CREATE TABLE public."Customers" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Email" text,
    "Phone" text
);


ALTER TABLE public."Customers" OWNER TO vestas;

--
-- TOC entry 203 (class 1259 OID 16400)
-- Name: Customers_Id_seq; Type: SEQUENCE; Schema: public; Owner: vestas
--

ALTER TABLE public."Customers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Customers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 206 (class 1259 OID 16412)
-- Name: Projects; Type: TABLE; Schema: public; Owner: vestas
--

CREATE TABLE public."Projects" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Description" text,
    "CustomerId" integer NOT NULL
);


ALTER TABLE public."Projects" OWNER TO vestas;

--
-- TOC entry 205 (class 1259 OID 16410)
-- Name: Projects_Id_seq; Type: SEQUENCE; Schema: public; Owner: vestas
--

ALTER TABLE public."Projects" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Projects_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 208 (class 1259 OID 16422)
-- Name: TimeInputs; Type: TABLE; Schema: public; Owner: vestas
--

CREATE TABLE public."TimeInputs" (
    "Id" integer NOT NULL,
    "ProjectId" integer NOT NULL,
    "TimeSpent" numeric NOT NULL
);


ALTER TABLE public."TimeInputs" OWNER TO vestas;

--
-- TOC entry 207 (class 1259 OID 16420)
-- Name: TimeInputs_Id_seq; Type: SEQUENCE; Schema: public; Owner: vestas
--

ALTER TABLE public."TimeInputs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."TimeInputs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 202 (class 1259 OID 16395)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: vestas
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO vestas;

--
-- TOC entry 2846 (class 0 OID 16402)
-- Dependencies: 204
-- Data for Name: Customers; Type: TABLE DATA; Schema: public; Owner: vestas
--

COPY public."Customers" ("Id", "Name", "Email", "Phone") FROM stdin;
1	customer1	c1@c1.c1	
2	customer2	email@email.com	
3	final costumer	someemail@email.com	
\.


--
-- TOC entry 2848 (class 0 OID 16412)
-- Dependencies: 206
-- Data for Name: Projects; Type: TABLE DATA; Schema: public; Owner: vestas
--

COPY public."Projects" ("Id", "Name", "Description", "CustomerId") FROM stdin;
1	Project1	Project for C2	2
2	Project2		2
3	Project3		2
4	Project4	Project for C1	1
5	Project5	test	1
6	Project6		1
7	final project	final	3
\.


--
-- TOC entry 2850 (class 0 OID 16422)
-- Dependencies: 208
-- Data for Name: TimeInputs; Type: TABLE DATA; Schema: public; Owner: vestas
--

COPY public."TimeInputs" ("Id", "ProjectId", "TimeSpent") FROM stdin;
1	5	2
2	3	2.6
3	1	5
4	5	3
5	1	5
6	5	1
7	7	7
8	7	0.6
\.


--
-- TOC entry 2844 (class 0 OID 16395)
-- Dependencies: 202
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: vestas
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20200920135155_InitialMigration	3.1.8
20200921095319_UpdatedProjectAndTimeInput	3.1.8
20200921095954_AddedRequiredFields	3.1.8
20200921102327_ChangedIdRelations	3.1.8
20200921103047_TestingSmth	3.1.8
20200921103819_TestingSmth_2	3.1.8
20200921104203_AddingFKs	3.1.8
20200922000913_changingTimeSpent	3.1.8
\.


--
-- TOC entry 2856 (class 0 OID 0)
-- Dependencies: 203
-- Name: Customers_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: vestas
--

SELECT pg_catalog.setval('public."Customers_Id_seq"', 1, true);


--
-- TOC entry 2857 (class 0 OID 0)
-- Dependencies: 205
-- Name: Projects_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: vestas
--

SELECT pg_catalog.setval('public."Projects_Id_seq"', 1, false);


--
-- TOC entry 2858 (class 0 OID 0)
-- Dependencies: 207
-- Name: TimeInputs_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: vestas
--

SELECT pg_catalog.setval('public."TimeInputs_Id_seq"', 1, false);


--
-- TOC entry 2709 (class 2606 OID 16409)
-- Name: Customers PK_Customers; Type: CONSTRAINT; Schema: public; Owner: vestas
--

ALTER TABLE ONLY public."Customers"
    ADD CONSTRAINT "PK_Customers" PRIMARY KEY ("Id");


--
-- TOC entry 2712 (class 2606 OID 16419)
-- Name: Projects PK_Projects; Type: CONSTRAINT; Schema: public; Owner: vestas
--

ALTER TABLE ONLY public."Projects"
    ADD CONSTRAINT "PK_Projects" PRIMARY KEY ("Id");


--
-- TOC entry 2715 (class 2606 OID 16426)
-- Name: TimeInputs PK_TimeInputs; Type: CONSTRAINT; Schema: public; Owner: vestas
--

ALTER TABLE ONLY public."TimeInputs"
    ADD CONSTRAINT "PK_TimeInputs" PRIMARY KEY ("Id");


--
-- TOC entry 2707 (class 2606 OID 16399)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: vestas
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 2710 (class 1259 OID 16464)
-- Name: IX_Projects_CustomerId; Type: INDEX; Schema: public; Owner: vestas
--

CREATE INDEX "IX_Projects_CustomerId" ON public."Projects" USING btree ("CustomerId");


--
-- TOC entry 2713 (class 1259 OID 16463)
-- Name: IX_TimeInputs_ProjectId; Type: INDEX; Schema: public; Owner: vestas
--

CREATE INDEX "IX_TimeInputs_ProjectId" ON public."TimeInputs" USING btree ("ProjectId");


--
-- TOC entry 2716 (class 2606 OID 16465)
-- Name: Projects FK_Projects_Customers_CustomerId; Type: FK CONSTRAINT; Schema: public; Owner: vestas
--

ALTER TABLE ONLY public."Projects"
    ADD CONSTRAINT "FK_Projects_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES public."Customers"("Id") ON DELETE CASCADE;


--
-- TOC entry 2717 (class 2606 OID 16470)
-- Name: TimeInputs FK_TimeInputs_Projects_ProjectId; Type: FK CONSTRAINT; Schema: public; Owner: vestas
--

ALTER TABLE ONLY public."TimeInputs"
    ADD CONSTRAINT "FK_TimeInputs_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES public."Projects"("Id") ON DELETE CASCADE;


-- Completed on 2020-09-22 20:17:30

--
-- PostgreSQL database dump complete
--

