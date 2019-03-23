<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="tareas">
    <html>
      <h5>Selected subject tasks</h5>
      <body>
        <table class="table table-sm table-bordered table-responsive-md table-hover table-row-middle">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Code</th>
              <th scope="col">Description</th>
              <th scope="col">Estimated Hours</th>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="./tarea">
              <tr>
                <td>
                  <xsl:value-of select="./@codigo"/>
                </td>
                <td>
                  <xsl:value-of select="./descripcion"/>
                </td>
                <td>
                  <xsl:value-of select="./hestimadas"/>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

