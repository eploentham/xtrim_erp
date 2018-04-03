select j.jobno, j.jobdate, j.imdate, j.departdd, j.bl
, j.housebl, j.importer, j.doctype, j.packtype, j.dcltype
, j.transmode, j.vslname, j.vslnamerem, j.origin, j.consignmnt
, j.loaded, j.released, j.out_released, j.approval
, j3.trading_partner_taxid, j3.trading_partner_branch, j.approvalno
, j3.ex_taxid_incentives
From job_2018 j
left join job_3_2018 j3 on j.jobno = j3.jobno